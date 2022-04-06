import './App.css';
import { Route, Routes } from 'react-router-dom';
import { Layout } from './components/Layout';
import { ReportsData } from './components/ReportsData';
import Home from './pages/Home';

import { FetchData } from './components/FetchData';

function App() {
  return (
    <Layout>
      <Routes>
        <Route path='/' index element={<Home/>} />
        <Route path='/fetch-data' element={<FetchData/>} />
        <Route path='/reports' element={<ReportsData/>} />
      </Routes>
    </Layout>
  );
}

export default App;