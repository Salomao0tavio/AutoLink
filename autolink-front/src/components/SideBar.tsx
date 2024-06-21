import React from 'react';
import classNames from 'classnames';
import { MdHome, MdDirectionsCar, MdAssignment, MdAttachMoney, MdPeople, MdBuild } from 'react-icons/md';

interface SidebarProps {
    isOpen: boolean;
    onClose: () => void;
}

const Sidebar: React.FC<SidebarProps> = ({ isOpen, onClose }) => {
    const sidebarClasses = classNames(
        'bg-gray-100', 
        'text-cerulean',
        'w-64',
        'py-4',
        'px-6',
        'fixed',
        'top-0',
        'left-0',
        'h-full',
        'z-50',
        { 'hidden': !isOpen }
    );

    const navigateTo = (path: string) => {
        onClose(); // Fecha a sidebar ao clicar em um link
        window.location.href = path;
    };

    return (
        <div className={sidebarClasses}>
            <div className="flex items-center justify-between mb-6">
                <div className="flex items-center">
                    <img src="/AutoLinkLogo.png" alt="logo" className="h-8 w-auto" />
                    <h1 className="text-lg font-bold ml-3">AutoLink</h1>
                </div>
                <button className=" focus:outline-none" onClick={onClose}>
                    <svg className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M6 18L18 6M6 6l12 12" />
                    </svg>
                </button>
            </div>
            <div className="space-y-4">
                <MenuItem icon={<MdHome />} text="Home" onClick={() => navigateTo("/")} />
                <MenuItem icon={<MdDirectionsCar />} text="Carros" onClick={() => navigateTo("/carros")} />
                <MenuItem icon={<MdAssignment />} text="Relatórios" onClick={() => navigateTo("/relatorios")} />
                <MenuItem icon={<MdAttachMoney />} text="Aluguéis" onClick={() => navigateTo("/alugueis")} />
                <MenuItem icon={<MdPeople />} text="Clientes" onClick={() => navigateTo("/clientes")} />
                <MenuItem icon={<MdBuild />} text="Manutenções" onClick={() => navigateTo("/manutencoes")} />
            </div>
        </div>
    );
};

const MenuItem: React.FC<{ icon: JSX.Element; text: string; onClick: () => void }> = ({ icon, text, onClick }) => (
    <div className="flex items-center hover:text-cerulean-darkest cursor-pointer" onClick={onClick}>
        {icon}
        <span className="ml-2">{text}</span>
    </div>
);

export default Sidebar;
