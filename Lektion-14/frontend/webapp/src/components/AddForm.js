import React, {useState} from 'react'

const AddForm = () => {
    const [customer, setCustomer] = useState({ id:0, name: '', email: '', customerTypeId: '0' })
  
    const submit = async (e) => {
        e.preventDefault()

        const result = await fetch('https://localhost:7049/api/Customers', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(customer)
        })

        console.log(await result.json())
    }

    return (
        <form onSubmit={submit} className="m-5">
            <input type="hidden" value={customer.id}></input>
            <input type="text" value={customer.name} onChange={(e) => setCustomer((currentData) => ({...currentData, name: e.target.value}))} className="mb-3 form-control" />
            <input type="text" value={customer.email} onChange={(e) => setCustomer((currentData) => ({...currentData, email: e.target.value}))} className="mb-3 form-control" />
            <select value={customer.customerTypeId} onChange={(e) => setCustomer((currentData) => ({...currentData, customerTypeId: e.target.value}))}  className="form-select mb-3">
                <option value="0">-- Ange en Kontakttyp --</option>
                <option value="1">Privatperson</option>
                <option value="2">Företag</option>
                <option value="3">VIP</option>
            </select>
            <button type="submit" className="btn btn-secondary">SKICKA</button> 
        </form>
    )
}

export default AddForm