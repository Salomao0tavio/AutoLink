import React from 'react';

interface FuncionalityCardProps {
    title: string;
    description: string;
    path: string;   
}

const FuncionalityCard: React.FC<FuncionalityCardProps> = ({ title, description, path}) => {
    const onClick = (path: string) => {
        window.location.href = path;
    };

    return (
        <div className={`p-6 rounded-lg shadow-md transition ease-in-out delay-150 bg-teal-800 hover:-translate-y-1 hover:scale-110 hover:bg-teal-900 duration-300`} onClick={() => onClick(path)}>
            <h4 className="text-2xl font-bold mb-2">{title}</h4>
            <p>{description}</p>
        </div>
    );
};

export default FuncionalityCard;
