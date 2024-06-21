import { PhotoIcon } from '@heroicons/react/24/outline';
import { TABLE_HEAD, TABLE_ROWS } from './data/data';

function ClientsList() {
    return (
        <div className="p-4">
            <div className="bg-white shadow-md rounded-lg overflow-hidden">
                <div className="overflow-x-auto">
                    <table className="w-full whitespace-nowrap">
                        <thead>
                            <tr className="bg-gray-300">
                                {TABLE_HEAD.map((head) => (
                                    <th
                                        key={head}
                                        className="border-b border-gray-200 px-4 py-2 text-xs sm:text-sm font-semibold text-blue-gray-700"
                                    >
                                        {head}
                                    </th>
                                ))}
                            </tr>
                        </thead>
                        <tbody>
                            {TABLE_ROWS.map(({ name, cpf, email, phone }, index) => {
                                const isLast = index === TABLE_ROWS.length - 1;
                                const rowClasses = isLast ? "bg-white" : "bg-white";

                                return (
                                    <tr
                                        key={name}
                                        className={`hover:bg-gray-50 transition-colors ${rowClasses}`}
                                    >
                                        <td className="border-b border-gray-200 px-4 py-3">
                                            <div className='flex items-center'>
                                                <span className="text-sm sm:text-base font-medium text-blue-gray-900">
                                                    {name}
                                                </span>
                                                <PhotoIcon className="w-5 h-5 ml-1 text-blue-gray-500" />
                                            </div>
                                        </td>
                                        <td className="border-b border-gray-200 px-4 py-3 text-sm sm:text-base text-blue-gray-900">
                                            {cpf}
                                        </td>
                                        <td className="border-b border-gray-200 px-4 py-3 text-sm sm:text-base text-blue-gray-900">
                                            {email}
                                        </td>
                                        <td className="border-b border-gray-200 px-4 py-3 text-sm sm:text-base text-blue-gray-900">
                                            {phone}
                                        </td>
                                        <td className="border-b border-gray-200 px-4 py-3 text-sm sm:text-base text-blue-gray-900">
                                            <a
                                                href="#"
                                                className="text-blue-600 hover:underline"
                                            >
                                                Edit
                                            </a>
                                        </td>
                                    </tr>
                                );
                            })}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}

export default ClientsList;
