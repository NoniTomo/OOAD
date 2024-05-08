import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Input from './input.js';
import Result from './result.js';


function App() {
  return (
    <BrowserRouter>
        <Routes>
            <Route path='/input' element={<Input />} />
            <Route path='/result' element={<Result />} />
            <Route path='*' element={<Input />} />
        </Routes>
    </BrowserRouter>
  );
}

export default App;
