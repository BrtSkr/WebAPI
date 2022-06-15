import React from 'react';
import './scss/main.scss';

import { NavMain, Listing } from './components/nav/nav';
const App = () => {
  return (
    <div className="App">
      <NavMain firstName='Test' middleName='test' lastName='ddd'/>
      <header className="App-header">
        <Listing />
       
      </header>
    </div>
  );
}

export default App;
