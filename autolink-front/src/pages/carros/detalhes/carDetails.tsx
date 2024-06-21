import React from 'react';
import { useParams } from 'react-router-dom';
import { mockCars } from '../data/data';

interface CarDetailsParams {
    id: string;
    [key: string]: string | undefined;
}

const CarDetails: React.FC = () => {
    const { id } = useParams<CarDetailsParams>();

    const car = mockCars.find(car => car.id === id);

    if (!car) return <p>Carro não encontrado</p>;

    return (
        <div className="container mx-auto px-4 py-8">
            <h1 className="text-4xl text-teal-900 mb-4 text-center">Detalhes do Carro</h1>
            <div className="p-4 flex flex-col md:flex-row items-center">
                <div className="md:w-1/2">
                    <h3 className="text-2xl font-bold text-teal-800 mb-2">{car.vehicle}</h3>
                    <p className='font-semibold mt-5'>Status: <span className='font-normal'>{car.status}</span></p>
                    <p className='font-semibold'>Preço: <span className='font-normal'>R${car.price.toFixed(2)}</span></p>
                </div>
                <div className="md:w-3/4 md:pl-4">
                    <img src="https://www.localiza.com/brasil-site/geral/Frota/ZOEE.png" alt={car.vehicle} className="w-full rounded-md" />
                </div>
            </div>
        </div>
    );
}

export default CarDetails;
