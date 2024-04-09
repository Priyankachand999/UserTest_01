import axios from 'axios';
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom'; 

const CategorySelectionComponent = () => {
    const [selectedCategory, setSelectedCategory] = useState('');
    const navigate = useNavigate(); 
  
    const onSelectCategory = (category) => {
        setSelectedCategory(category);
        console.log(selectedCategory);
  
        navigate(`/Test/${category.toLowerCase()}`);
    };    

    const handleCategoryChange = (event) => {
      setSelectedCategory(event.target.value);
    }; 


    const handleSubmit = () => {
        onSelectCategory(selectedCategory);
      };    return (
        <div>
            <h2>Select Category</h2>
            <div>
                <input
                    type="radio"
                    id="general"
                    name="category"
                    value="General"
                    checked={selectedCategory === 'General'}
                    onChange={handleCategoryChange}
                />
                <label htmlFor="general">General</label>
            </div>
            <div>
                <input
                    type="radio"
                    id="science"
                    name="category"
                    value="Science"
                    checked={selectedCategory === 'Science'}
                    onChange={handleCategoryChange}
                />
                <label htmlFor="science">Science</label>
            </div>
            <div>
                <input
                    type="radio"
                    id="history"
                    name="category"
                    value="History"
                    checked={selectedCategory === 'History'}
                    onChange={handleCategoryChange}
                />
                <label htmlFor="history">History</label>
            </div>
            <div>
                <input
                    type="radio"
                    id="it"
                    name="category"
                    value="IT"
                    checked={selectedCategory === 'IT'}
                    onChange={handleCategoryChange}
                />
                <label htmlFor="it">IT</label>
            </div>
            <button onClick={handleSubmit} disabled={!selectedCategory}>Start Test</button>
        </div>
    );
};

export default CategorySelectionComponent;
