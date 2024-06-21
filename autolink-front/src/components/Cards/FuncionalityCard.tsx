import React from 'react';
import { IconType } from 'react-icons';

interface FuncionalityCardProps {
    title: string;
    description: string;
    path: string;
    icon: IconType;
}

const FuncionalityCard: React.FC<FuncionalityCardProps> = ({ title, description, path, icon: Icon }) => {
    const onClick = (path: string) => {
        window.location.href = path;
    };

    return (
        <div className="p-6 rounded-lg transition ease-in-out delay-150 shadow-md border-2 border-cerulean-light 
        hover:-translate-y-1 hover:scale-110 hover:bg-cerulean-lightest duration-300 cursor-pointer hover:text-white" onClick={() => onClick(path)}>
            <div className="flex items-center mb-4">
                <Icon className="text-3xl mr-2 text-cerulean-darkest" />
                <h4 className="text-2xl font-bold text-cerulean-darkest ">{title}</h4>
            </div>
            <p className="text-cerulean-darkest ">{description}</p>
        </div>
    );
};

export default FuncionalityCard;
