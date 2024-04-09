import axios from 'axios';
import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './Register.css'; // Import custom CSS for styling

function Register() {
    const [form, setForm] = useState({ name: "", email: "", address: "", password: "", role: "" });
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {            
            const { name, email, address, password, role } = form;         
            const response = await axios.post("https://localhost:7108/api/Register/register", { 
                name,
                email,
                address,
                password,
                role
            });

            if (response.status === 200) {
                alert('User registered successfully!');
                navigate('/login');
            } else {
                alert(`Registration failed with status: ${response.status}`);   
            }
        } catch (error) {
            console.error('Error registering user:', error);
            alert('Registration failed !! Network error');
        }
    };

    const handleChange = (event) => {
       
        setForm({ ...form, [event.target.name]: event.target.value });
    };

    return (
        <div className="container">
            <div className="register-container">
                <h2 className="register-header">User Registration</h2>
                <form className="register-form" onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="name" className="form-label">Name</label>
                        <input type="text" className="form-control" id="name" name="name" value={form.name} onChange={handleChange} required />
                    </div>
                    <div className="form-group">
                        <label htmlFor="address" className="form-label">Address</label>
                        <input type="text" className="form-control" id="address" name="address" value={form.address} onChange={handleChange} required />
                    </div>
                    <div className="form-group">
                        <label htmlFor="email" className="form-label">Email</label>
                        <input type="email" className="form-control" id="email" name="email" value={form.email} onChange={handleChange} required />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password" className="form-label">Password</label>
                        <input type="password" className="form-control" id="password" name="password" value={form.password} onChange={handleChange} required />
                    </div>
                    <button type="submit" className="btn btn-register">Register</button>
                </form>
                <div className="text-center mt-3">
                    <p>Already have an account? <Link className="nav-link" to="/login">Login Here</Link></p>
                </div>
                <div className="text-center mt-3">
                    <p>View your profile? <Link className="nav-link" to="/profile">Profile</Link></p>
                </div>
            </div>
        </div>
    );
}

export default Register;
