import { useEffect, useState } from 'react';
import { mockCars } from './data/data';
import Button from '../../components/Buttons/CreateButton';
import CarList from './carList';
import Loading from '../../components/Loading';

interface Car {
    id: string;
    vehicle: string;
    status: string;
    price: number;
}

export const Cars = () => {
    const [cars, setCars] = useState<Car[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        setTimeout(() => {
            try {
                setCars(mockCars);
            } catch (err) {
                setError('Erro ao buscar os aluguéis');
            } finally {
                setLoading(false);
            }
        }, 1000);
    }, []);

    const handleAddCar = () => {
        const newCar: Car = {
            id: (cars.length + 1).toString(),
            status: 'Disponível',
            vehicle: `Carro ${String.fromCharCode(65 + cars.length)}`,
            price: 100 + cars.length * 50,
        };
        setCars([...cars, newCar]);
    };

    if (loading)
        return <Loading/>;
   
    if (error) return <p>{error}</p>;

    return (
        <>
             <h1 className="text-center font-semibold text-4xl text-teal-900 pt-5 pb-10 ">Carros</h1>
            <div className="m-2 fixed right-2 bottom-2 ">
                <Button onClick={handleAddCar} label="Adicionar Carro" />
            </div>
            <div className="container mx-auto px-4 flex justify-center">
                {cars.length === 0 ? (
                    <p className="text-center">Nenhum carro encontrado.</p>
                ) : (
                    <CarList cars={cars} />
                )}
            </div>
        </>
    );
};

export default Cars;
