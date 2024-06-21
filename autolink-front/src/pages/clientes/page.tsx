import Button from "../../components/Buttons/CreateButton"
import Table from '../../components/Table';
import { TABLE_HEAD, TABLE_ROWS } from './data/data';

interface ClientData {
    name: string;
    cpf: string;
    email: string;
    phone: string;
}

export const Clients = () => {
    return (
        <>
            <h1 className="text-center font-semibold text-4xl text-teal-900 pt-5 pb-10 ">Clientes</h1>
            <div className="m-2 fixed right-2 bottom-2 ">
                <Button onClick={() => {}} label="Adicionar Cliente" />
            </div>
            <Table headers={TABLE_HEAD} rows={TABLE_ROWS.map(({ name, cpf, email, phone }: ClientData) => ([name, cpf, email, phone,]))}/>
  
        </>
    )
}