import React, { useState } from 'react'

const StatusForm = () => {
    const [status, setStatus] = useState('')

    const handleChange = (e) => {
        setStatus(e.target.value)
    }

    const handleSubmit = async (e) => {
        e.preventDefault()
        
        const json = JSON.stringify({ status: e.target[0].value })
        const res = await fetch('https://localhost:7145/api/statuses', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: json
        })
        console.log(await res.json())
        setStatus('')
    }
    
    return (
        <form onSubmit={handleSubmit}>
            <div className="mb-3">
                <label className="form-label">Ange status</label>
                <input type="text" className="form-control" value={status} onChange={handleChange} />
            </div>
            <button type="submit" className="btn btn-success">Spara</button>
        </form>
    )
}

export default StatusForm