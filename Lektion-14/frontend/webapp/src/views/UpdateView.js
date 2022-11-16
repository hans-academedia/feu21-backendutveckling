import React from 'react'
import { useParams } from 'react-router-dom'
import UpdateForm from '../components/UpdateForm'

const UpdateView = () => {
    const {id} = useParams()

    return (
        <UpdateForm id={id} />
    )
}

export default UpdateView