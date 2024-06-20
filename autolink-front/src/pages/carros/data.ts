interface Car {
    id: string;
    vehicle: string;
    status: string;  
    price: number;
}


export const mockCars: Car[] = [
    {
        id: '1',
        vehicle: 'Carro A',
        status: 'Disponível',
        price: 100,
    },
    {
        id: '2',
        vehicle: 'Carro B',
        status: 'Em manutenção',
        price: 150,
    },
    {
        id: '3',
        vehicle: 'Carro C',
        status: 'Indisponível',
        price: 200,
    }
];