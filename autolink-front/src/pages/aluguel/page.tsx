import React from 'react';
import Table from '../../components/Table';
import { RENT_DATA } from './data/data';
import Button from '../../components/Buttons/CreateButton';

interface RentData {
    id: number;
    cliente: string;
    carro: string;
    dataInicio: string;
    dataFim: string;
    valor: number;
    status: string;
}

const Rents: React.FC = () => {
    return (
        <div className="p-4">
            <h1 className="text-center font-semibold text-4xl text-teal-900 pt-5 pb-10 ">Aluguéis</h1>
            <div className="m-2 fixed right-2 bottom-2 ">
                <Button onClick={() => { }} label="Adicionar Aluguel" />
            </div>
            <Table
                headers={[
                    'Cliente',
                    'Carro',
                    'Data de Início',
                    'Data de Fim',
                    'Valor (R$)',
                    'Status',
                ]}
                rows={RENT_DATA.map(({ cliente, carro, dataInicio, dataFim, valor, status }: RentData) => ([
                    cliente,
                    carro,
                    dataInicio,
                    dataFim,
                    valor.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' }),
                    status,
                ].map(item => String(item))))}
            />
        </div>
    );
}

export default Rents;
