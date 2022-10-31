const handleSubmit = async (e) => {
    e.preventDefault()

    const json = JSON.stringify({ statusName: e.target[0].value })

    const res = await fetch('https://localhost:7105/api/Statuses', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: json
    })
}


const handleIssueSubmit = async (e) => {
    e.preventDefault()

    const json = JSON.stringify({ subject: e.target[1].value, message: e.target[2].value })
    const res = await fetch('https://localhost:7105/api/issues', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: json
    })

    const data = await res.json()
    console.log(data)
}

const handleUpdateIssueSubmit = async (e) => {
    e.preventDefault()

    const json = JSON.stringify({ statusId: e.target[0].value, subject: e.target[1].value, message: e.target[2].value })
    const res = await fetch(`https://localhost:7105/api/issues/1`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: json
    })

    const data = await res.json()
    console.log(data)
}

const populateStatus = async () => {
    const selectbox = document.getElementById('status')
    const res = await fetch('https://localhost:7105/api/Statuses')
    const data = await res.json()
    
    for(let item of data) {
        selectbox.innerHTML += `<option value="${item.id}">${item.name}</option>`
    }
    
}

const getIssue = async (id) => {
    const res = await fetch(`https://localhost:7105/api/issues/${id}`)
    const data = await res.json()

    document.getElementById('subject').value = data.subject
    document.getElementById('message').value = data.message
}