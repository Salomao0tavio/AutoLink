import { useState } from 'react';
import Sidebar from '../components/SideBar';
import { AiOutlineMenu } from 'react-icons/ai';

const Header = () => {
    const [sidebarOpen, setSidebarOpen] = useState(false);

    const toggleSidebar = () => {
        setSidebarOpen(!sidebarOpen);
    };

    return (
        <header className="bg-cerulean-lightest shadow-md">
            <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-4">
                <div className="flex justify-between items-center">
                    <div className="">
                        <button
                            className="text-dark-slate-gray hover:text-dark-slate-gray-darkest focus:outline-none"
                            onClick={toggleSidebar}
                        >
                            <AiOutlineMenu className="text-2xl" />
                        </button>
                    </div>
                    <div className="flex items-center">
                        <img src="/AutoLinkLogo.png" alt="logo" className="h-12 w-auto" />
                        <h1 className="text-xl font-bold ml-3">AutoLink</h1>
                    </div>

                </div>
            </div>
            <Sidebar isOpen={sidebarOpen} onClose={() => setSidebarOpen(false)} />
        </header>
    );
};

export default Header;
