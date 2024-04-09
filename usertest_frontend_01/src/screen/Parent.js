// // ParentComponent.js
// import React, { useState } from 'react';
// import CategorySelectionComponent from './CategorySelectionComponent';
// import TestComponent from './TestComponent';

// const ParentComponent = () => {
//   const [selectedCategory, setSelectedCategory] = useState('');

//   const handleCategorySelect = (category) => {
//     setSelectedCategory(category);
//   };

//   return (
//     <div>
//       {!selectedCategory && <CategorySelectionComponent onSelectCategory={handleCategorySelect} />}
//       {selectedCategory && <TestComponent category={selectedCategory} />}
//     </div>
//   );
// };

// export default ParentComponent;
