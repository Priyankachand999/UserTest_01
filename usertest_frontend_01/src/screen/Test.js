import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';

const TestComponent = () => {
  const [testQuestions, setTestQuestions] = useState([]);
  const [selectedAnswers, setSelectedAnswers] = useState({});
  const [currentPage, setCurrentPage] = useState(0);
  const [submitted, setSubmitted] = useState(false);
  const [score, setScore] = useState(null);
  const [timeLeft, setTimeLeft] = useState(5); // Timer for 5 seconds
  const [timerActive, setTimerActive] = useState(false);

  const { category: urlCategory } = useParams();

  useEffect(() => {
    if (urlCategory) {
      fetchAndShuffleTestQuestions(urlCategory);
    }
  }, [urlCategory]);
  
  useEffect(() => {
    if (timerActive && timeLeft > 0) {
      const timer = setTimeout(() => {
        setTimeLeft(timeLeft - 1);
      }, 1000);

      return () => clearTimeout(timer);
    } else if (timerActive && timeLeft === 0) {
      handleNext();
    }
  }, [timerActive, timeLeft]);

  const fetchAndShuffleTestQuestions = async (category) => {
    try {
      const token = localStorage.getItem('token');
      if (!token) {
        console.error('Token is not available in localStorage');
        return;
      }
  
      const headers = {
        'Authorization': `Bearer ${token}`
      };
      
      const response = await axios.get(`https://localhost:7108/api/Test/${category}`, { headers });
      const shuffledQuestions = shuffleArray(response.data); // Shuffle the questions
      setTestQuestions(shuffledQuestions);
      startTimer(); // Start timer when questions are fetched
    } catch (error) {
      console.error(`Error fetching ${category} test questions:`, error);
    }
  };
  const shuffleArray = (array) => {
    // Fisher-Yates shuffle algorithm
    for (let i = array.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [array[i], array[j]] = [array[j], array[i]];
    }
    return array;
  };

  const startTimer = () => {
    setTimeLeft(5); // Reset timer to 5 seconds
    setTimerActive(true); // Start timer
  };

  const stopTimer = () => {
    setTimerActive(false); // Stop timer
  };

  const handleOptionChange = (questionId, option) => {
    setSelectedAnswers({
      ...selectedAnswers,
      [questionId]: option
    });
  };

  const handleNext = () => {
    if (currentPage < testQuestions.length - 1) {
      setCurrentPage(currentPage + 1);
      startTimer(); // Start timer for the next question
    } else {
      handleSubmit();
    }
  };

  const handleSubmit = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) {
        console.error('Token is not available in localStorage');
        return;
      }

      const headers = {
        'Authorization': `Bearer ${token}`
      };
  
      const response = await axios.post('https://localhost:7108/api/Test/submit', selectedAnswers, { headers });
      setScore(response.data);
      setSubmitted(true);
    } catch (error) {
      console.error('Error submitting test:', error);
    }
  };

  return (
    <div>
      {submitted ? (
        <div>
          <h3>Test Submitted!</h3>
          <p>Your score: {score}</p>
        </div>
      ) : (
        <div>
          <h2>Question {currentPage + 1}</h2>
          <h3>{testQuestions[currentPage]?.question}</h3>
          <p>Time left: {timeLeft} seconds</p>
          <ul>
            {testQuestions[currentPage]?.options.split(',').map((option, index) => (
              <li key={index}>
                <label>
                  <input
                    type="radio"
                    name={`question_${testQuestions[currentPage]?.id}`}
                    value={option}
                    checked={selectedAnswers[testQuestions[currentPage]?.id] === option}
                    onChange={() => handleOptionChange(testQuestions[currentPage]?.id, option)}
                    onClick={stopTimer} // Stop timer when option is clicked
                  />
                  {option}
                </label>
              </li>
            ))}
          </ul>
          <button onClick={handleNext}>{currentPage < testQuestions.length - 1 ? 'Next' : 'Submit'}</button>
        </div>
      )}
    </div>
  );
};

export default TestComponent;

