import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Header from './screen/Header';
import Home from './screen/Home';
import Login from './screen/Login';
import Register from './screen/Register';
import Test from './screen/Test';
import axios from 'axios'; // Import axios without curly braces
import { useEffect, useState } from 'react';
import CategorySelection from './screen/CategorySelection';
import Profile from './screen/Profile';

function App() {
  const [isTokenValid, setIsTokenValid] = useState(false);

  useEffect(() => {
    const checkTokenValidity = async () => {
      const token = localStorage.getItem('token');
      if (token) {
        try {
          const response = await axios.post('https://localhost:7108/api/Register/validtoken', { token });
          if (response.status === 200) {
            // Token is valid
            setIsTokenValid(true);  
          } else {
            // Token is invalid or expired
            console.log('Token is invalid or expired');
            setIsTokenValid(false);
            localStorage.removeItem('token');
          }
        } catch (error) {
          console.error('Token validation failed:', error.response ? error.response.data.error : error.message);
          setIsTokenValid(false);
          localStorage.removeItem('token');
        }
      }
    };

    checkTokenValidity();
  }, []);

  return (
    <div className="App">
      <BrowserRouter>
        <Header />
        <Routes>
          {/* Always render Home route */}
          <Route path="/" element={<Home />} />

          {/* Conditional rendering of routes based on token validity */}
          {isTokenValid ? (
            <>
            <Route path="/Test/:category" element={<Test />} />
              <Route path="/category" element={<CategorySelection />} />
              <Route path="/profile" element={<Profile />} />

            </>
          ) : (
            <>
              <Route path="login" element={<Login />} />
              <Route path="register" element={<Register />} />
            </>
          )}
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
