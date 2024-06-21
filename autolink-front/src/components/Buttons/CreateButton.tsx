import { PlusCircleIcon } from "@heroicons/react/24/outline";

export default function Button({ onClick, label }: { onClick: () => void, label: string }) {
  
    return (
        <button 
            className="flex items-center justify-center bg-dark-slate-gray hover:bg-dark-slate-gray-dark text-white font-semibold py-2 px-4 rounded-md shadow-md transition duration-300 ease-in-out transform hover:scale-105 focus:outline-none focus:ring-2 focus:ring-teal-500 focus:ring-opacity-50"
            onClick={onClick}
        >
            <PlusCircleIcon className="w-6 h-6 mr-2" />
            <span>{label}</span>
        </button>
    );
}
