import axios from 'axios';
import React, { useEffect, useState } from 'react';
// import './Profile.css'; // Import custom CSS for styling

function Profile() {
    const [userProfile, setUserProfile] = useState(null);

    useEffect(() => {
        const fetchProfile = async () => {
            try {
                const response = await axios.get("https://localhost:7108/api/Register/profile");
                setUserProfile(response.data);
            } catch (error) {
                console.error('Error fetching user profile:', error);
            }
        };

        fetchProfile();
    }, []);

    return (
        <div className="container">
            <div className="profile-container">
                <h2 className="profile-header">User Profile</h2>
                {userProfile ? (
                    <div>
                        <p><strong>Name:</strong> {userProfile.name}</p>
                        <p><strong>Email:</strong> {userProfile.email}</p>
                        <p><strong>Address:</strong> {userProfile.address}</p>
                        <p><strong>Role:</strong> {userProfile.role}</p>
                        {/* Display test results if available */}
                        {userProfile.testResults && (
                            <div>
                                <h3>Test Results</h3>
                                <ul>
                                    {userProfile.testResults.map((testResult, index) => (
                                        <li key={index}>
                                            <p><strong>Question:</strong> {testResult.question}</p>
                                            <p><strong>Selected Option:</strong> {testResult.selectedOption}</p>
                                            <p><strong>Correct Option:</strong> {testResult.correctOption}</p>
                                            <p><strong>Is Correct:</strong> {testResult.isCorrect ? 'Yes' : 'No'}</p>
                                        </li>
                                    ))}
                                </ul>
                            </div>
                        )}
                    </div>
                ) : (
                    <p>Loading...</p>
                )}
            </div>
        </div>
    );
}

export default Profile;
