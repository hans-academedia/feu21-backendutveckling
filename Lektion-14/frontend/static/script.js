const submitData = async (e) => {
    e.preventDefault()

    const data = {
        name: e.target[0].value,
        email: e.target[1].value,
        customerTypeId: Number(e.target[2].value)
    }

    const result = await fetch('https://localhost:7049/api/Customers', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })

    console.log(await result.json())

}

const updateData = async (e) => {
    e.preventDefault()

    const data = {
        id: e.target[0].value,
        name: e.target[1].value,
        email: e.target[2].value,
        customerTypeId: Number(e.target[3].value)
    }

    const result = await fetch('https://localhost:7049/api/Customers/' + data.id, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })

    console.log(await result.json())
    getCustomerData(data.id)
}


const getCustomerData = async (id) => {
    const result = await fetch('https://localhost:7049/api/Customers/' + id)
    const data = await result.json()

    document.getElementById('id').value = data.id
    document.getElementById('name').value = data.name
    document.getElementById('email').value = data.email

    document.getElementById('customerType').value = data.customerTypeId
}