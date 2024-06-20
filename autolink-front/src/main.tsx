import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import { Home } from './pages/home';
import { Cars } from './pages/carros';
import Header from './components/Header';
import { Rents } from './pages/alugueis';
import { Clients } from './pages/clientes';
import { Reports } from './pages/relatorios';
import { Maintence } from './pages/manutencao';
import { ThemeProvider } from "@material-tailwind/react";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
  },
  {
    path: "/carros",
    element: <Cars />,
  },
  {
    path: "/alugueis",
    element: <Rents />,
  },
  {
    path: "/clientes",
    element: <Clients />,
  },
  {
    path: "/mautencoes",
    element: <Maintence />,
  },
  {
    path: "/relatorios",
    element: <Reports />,
  },
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <ThemeProvider>
      <Header />
      <RouterProvider router={router} />
    </ThemeProvider>
  </React.StrictMode>,
)
