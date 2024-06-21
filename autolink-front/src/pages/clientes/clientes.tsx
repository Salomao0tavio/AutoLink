import Button from "../../components/Buttons/CreateButton"
import ClientsList from "./clientesList"

export const Clients = () => {
    return (
        <>
            <h1 className="text-center font-medium text-4xl text-teal-900 pt-5 pb-10 ">Clientes</h1>
            <div className="m-2 fixed right-2 bottom-2 ">
                <Button onClick={() => {}} label="Adicionar Cliente" />
            </div>
            <ClientsList />
        </>
    )
}