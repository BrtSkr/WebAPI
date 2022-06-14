import React from 'react';
import './scss/main.scss';

import { NavMain } from './components/nav/nav';
const App = () => {
  return (
    <div className="App">
      <NavMain firstName='Test' middleName='test' lastName='ddd'/>
      <header className="App-header">
        
       
      </header>
    </div>
  );
}

export default App;
