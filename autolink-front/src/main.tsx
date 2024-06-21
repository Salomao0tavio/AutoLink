import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import { Home } from './pages/home';
import Header from './components/Header';
import { Clients } from './pages/clientes/clientes';
import { Reports } from './pages/relatorios/relatorios';
import { Maintenance } from './pages/manutencao/manutencao';
import { ThemeProvider } from "@material-tailwind/react";
import { Cars } from './pages/carros/page';
import { Rents } from './pages/aluguel/aluguel';
import CarDetails from './pages/carros/detalhes/carDetails';

const router = createBrowserRouter([
  { path: "/", element: <Home />, },
  { path: "/carros", element: <Cars />, },
  { path: "/alugueis", element: <Rents />, },
  { path: "/clientes", element: <Clients />, },
  { path: "/manutencoes", element: <Maintenance />, },
  { path: "/relatorios", element: <Reports />, },
  { path: "/carro/detalhes/:id", element: <CarDetails /> }
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <ThemeProvider>
      <Header />
      <RouterProvider router={router} />
    </ThemeProvider>
  </React.StrictMode>,
)