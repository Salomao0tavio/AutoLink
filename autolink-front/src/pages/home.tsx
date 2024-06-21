import FuncionalityCard from '../components/Cards/FuncionalityCard';
import { FaCar, FaChartLine, FaWrench, FaUsers } from 'react-icons/fa';
import { MdDirectionsCar } from 'react-icons/md';

export function Home() {
    return (
        <main className="flex-grow container lg:max-w-7xl mx-auto px-4  py-10">
            <section className="text-center">
                <h2 className="text-4xl font-bold text-gray-900 mb-4">Bem-vindo à AutoLink</h2>
                <p className="text-gray-800">Esta é a página inicial da aplicação. Aqui você pode encontrar informações e funcionalidades interessantes.</p>
            </section>
            <section className="mt-10 text-center m-4 ">
                <h3 className="text-3xl font-bold  text-gray-900 mb-10">Funcionalidades</h3>

                <div className="grid grid-cols-1 md:grid-cols-3 gap-14 ">
                    <FuncionalityCard
                        title="Aluguéis"
                        description="Aqui você pode visualizar e gerenciar os aluguéis de veículos."
                        path="/alugueis"
                        icon={FaCar}
                    />
                    <FuncionalityCard
                        title="Carros"
                        description="Aqui você pode visualizar e gerenciar seus veículos."
                        path="/carros"
                        icon={MdDirectionsCar}
                    />
                    <FuncionalityCard
                        title="Relatórios"
                        description="Relatório de vendas, incluindo receita total, aluguéis por categoria e aluguéis por período."
                        path="/relatorios"
                        icon={FaChartLine}
                    />
                </div>

                <div className="grid grid-cols-1 md:grid-cols-2 mt-10 gap-14 min-h-36">
                    <FuncionalityCard
                        title="Manutenções"
                        description="Aqui você pode visualizar e gerenciar as manutenções dos veículos."
                        path="/manutencoes"
                        icon={FaWrench}
                    />
                    <FuncionalityCard
                        title="Clientes"
                        description="Aqui você pode visualizar e gerenciar os clientes da locadora."
                        path="/clientes"
                        icon={FaUsers}
                    />
                </div>
            </section>
        </main>
    );
}

export default Home;
