import axios from 'axios';
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './login.css';


function Login() {
    const [formData, setFormData] = useState({
        email: '',
        password: ''
    });
    const navigate = useNavigate(); 

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post("https://localhost:7108/api/Register/login", formData);
    
            if (response.status === 200) {
                const token = response.data; // Assuming the token is directly returned in the response
                if (!token) {
                    console.error('Token is missing in the server response');
                    return;
                }
    
                // Set the received token in local storage
                localStorage.setItem('token', token);
                console.log('Token stored in localStorage:', token);
    
                // Perform other actions after successful login
                // For example, navigate to another page
                navigate('/category');
                window.location.reload();
            } else {
                alert('Login failed. Please check your credentials.');
            }
        } catch (error) {
            console.error('Error logging in:', error);
            alert('Login failed. Please try again later.');
        }
    };

    return (
        <div className="container">
            <div className="row justify-content-center mt-5">
                <div className="col-md-6">
                    <div className="card custom-card">
                        <div className="card-body">
                            <h2 className="text-center mb-4">User Login</h2>
                            <form onSubmit={handleSubmit}>
                                <div className="mb-3">
                                    <label htmlFor="email" className="form-label"><strong>Email:</strong></label>
                                    <input type="email" className="form-control" id="email" name="email" value={formData.email} onChange={handleChange} required />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="password" className="form-label"><strong>Password:</strong></label>
                                    <input type="password" className="form-control" id="password" name="password" value={formData.password} onChange={handleChange} required />
                                </div>
                                <div className="text-center">
                                    <button className="btn btn-primary btn-lg" type="submit">Login</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Login;
