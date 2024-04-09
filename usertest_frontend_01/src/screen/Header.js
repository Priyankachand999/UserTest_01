import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';


function Header() {
  const [isLoggedIn, setIsLoggedIn] = useState(localStorage.getItem('token') !== null);
  const navigate = useNavigate();


  const handleLogout = () => {
    localStorage.removeItem('token');
    setIsLoggedIn(false);
    // Refresh the page
    navigate('/login');
    window.location.reload();
  };

  return (
    <div>
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav">
              { isLoggedIn ?(
                <>
              <li className="nav-item">
                <Link className="nav-link" to="/profile">Profile</Link>
              </li>

              <li className="nav-item">
                <Link className="nav-link" to="/category">CategorySelection</Link>
              </li>


                </>
              ):(<>
                            <li className="nav-item">
                <Link className="nav-link" to="/home">Home</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/register">Register</Link>
              </li>

              </>
            )}
            </ul>
            {isLoggedIn && (
                          <div className="ml-auto">
                          <button className="form-inline my-2 my-lg-0 btn btn-outline-danger my-2 my-sm-0" onClick={handleLogout}>Logout</button>
                                      </div>
            
            )}
          </div>
        </nav>
      </div>
  );
}

export default Header;
