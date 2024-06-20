import React from 'react';
import CarCard from '../../components/Cards/CarCard';

interface Car {
    id: string;
    vehicle: string;
    status: string;
    price: number;
}

interface CarListProps {
    cars: Car[];
}

const CarList: React.FC<CarListProps> = ({ cars }) => {
    return (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
            {cars.map(car => (
                <CarCard
                    key={car.id}
                    id={car.id}
                    vehicle={car.vehicle}
                    status={car.status}
                    price={car.price}
                />
            ))}
        </div>
    );
}

export default CarList;
