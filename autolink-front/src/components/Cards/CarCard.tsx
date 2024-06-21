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
        <div className="p-4  rounded-md shadow-md max-w-xs border-2 border-dark-slate-gray-lightest">
            <h3 className="text-2xl font-bold text-dark-slate-gray mb-2">{vehicle}</h3>
            <div className="carousel mb-4">
                <img src="https://www.localiza.com/brasil-site/geral/Frota/ZOEE.png" alt={vehicle} className="w-full rounded-md" />
            </div>
            <p className='font-semibold text-dark-slate-gray'>
                Status: <span className='font-normal'>{status}</span>
            </p>
            <p className='font-semibold text-dark-slate-gray'>
                Preço: <span className='font-normal'>R${price.toFixed(2)}</span>
            </p>
            <div className='flex flex-col'>
                <button className="mt-4 bg-dark-slate-gray-light hover:bg-dark-slate-gray text-white font-semibold py-2 px-4 rounded-md">
                    Reserve agora
                </button>
                <button className="mt-2 text-dark-slate-gray hover:underline" onClick={handleDetailsClick}>
                    Mostrar detalhes
                </button>
            </div>
        </div>
    );
}

export default CarCard;
