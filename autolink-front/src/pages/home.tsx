export function Home() {

    const onClick = (path: string) => {
        window.location.href = path;
    }

    const transition = 'transition ease-in-out delay-150 bg-teal-800 hover:-translate-y-1 hover:scale-110 hover:bg-teal-900 duration-300';

    return (
        <main className="flex-grow container lg:max-w-7xl mx-auto px-4 py-10">
            <section className="text-center">
                <h2 className="text-4xl font-bold text-gray-800 mb-4">Bem-vindo à AutoLink</h2>
                <p className="text-gray-600">Esta é a página inicial da aplicação. Aqui você pode encontrar informações e funcionalidades interessantes.</p>
            </section>
            <section className="mt-10 text-center m-4 text-white">
                <h3 className="text-3xl font-bold  text-gray-800 mb-10 ">Funcionalidades</h3>

                <div className="grid grid-cols-1 md:grid-cols-3 gap-14" >
                    <div className={`p-6 rounded-lg shadow-md ${transition}`} onClick={() => onClick("/alugueis")}>
                        <h4 className="text-2xl font-bold mb-2">Aluguéis</h4>
                        <p>Aqui você pode visualizar e gerenciar os aluguéis de veículos.</p>
                    </div>
                    <div className={`p-6 rounded-lg shadow-md ${transition}`} onClick={() => onClick("/carros")}>
                        <h4 className="text-2xl font-bold mb-2">Carros</h4>
                        <p>Aqui você pode visualizar e gerenciar seus veículos.</p>
                    </div>
                    <div className={`p-6 rounded-lg shadow-md ${transition}`} onClick={() => onClick("/relatorios")}>
                        <h4 className="text-2xl font-bold mb-2">Relatorios</h4>
                        <p>Relatório de vendas, incluindo receita total, aluguéis por categoria e aluguéis por período.</p>
                    </div>
                </div>

                <div className="grid grid-cols-1 md:grid-cols-2 mt-10 gap-14 min-h-36 ">
                    <div className={`p-6 rounded-lg shadow-md ${transition}`} onClick={() => onClick("/manutencoes")}>
                        <h4 className="text-2xl font-bold mb-2">Manutenções</h4>
                        <p>Aqui você pode visualizar e gerenciar as manutenções dos veículos.</p>
                    </div>

                    <div className={`p-6 rounded-lg shadow-md ${transition}`} onClick={() => onClick("/clientes")}>
                        <h4 className="text-2xl font-bold mb-2">Clientes</h4>
                        <p>Aqui você pode visualizar e gerenciar os clientes da locadora.</p>
                    </div>
                </div>

            </section>
        </main>

    );
}
