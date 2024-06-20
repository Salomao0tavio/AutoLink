import React from 'react';
import { useNavigate } from 'react-router-dom';

interface CarCardProps {
    id: string;
    vehicle: string;
    status: string;
    price: number;
}

const CarCard: React.FC<CarCardProps> = ({ id, vehicle, status, price }) => {
    const navigate = useNavigate();

    const handleDetailsClick = () => {
        navigate(`/carro/detalhes/${id}`);
    };

    return (
        <div className="p-4 bg-gray-100 rounded-md shadow max-w-xs">
            <h3 className="text-2xl font-bold text-teal-800 mb-2">{vehicle}</h3>
            <div className="carousel">
                <img src="https://www.localiza.com/brasil-site/geral/Frota/ZOEE.png" alt={vehicle} className="w-full rounded-md" />
            </div>
            <p className='font-semibold mt-5'>Status:
                <text className='font-normal'>{status}</text>
            </p>
            <p className='font-semibold'>Preço:
                <text className='font-normal'>R${price.toFixed(2)}</text>
            </p>
            <div className='flex flex-col'>
                <button className="mt-4 bg-teal-600 hover:bg-teal-700 text-white font-semibold py-2 px-4 rounded-md">Reserve agora</button>
                <button className="mt-2 text-teal-600 hover:underline" onClick={handleDetailsClick}>Mostrar detalhes</button>
            </div>
        </div>
    );
}

export default CarCard;
