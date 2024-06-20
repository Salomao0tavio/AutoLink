export default function Header() {
    return (
        <header className="bg-teal-600 w-full flex items-center justify-around p-3">
            <div className="flex items-center">
                <img src="/AutoLinkLogo.png" alt="logo" width={60} height={60} />
                <h1 className="text-xl font-bold text-white ml-3">AutoLink</h1>
            </div>
        </header>
    );
}
