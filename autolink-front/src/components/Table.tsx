import React from 'react';
import { PhotoIcon } from '@heroicons/react/24/outline';

interface TableProps {
    headers: string[];
    rows: (string | JSX.Element)[][];
}

const Table: React.FC<TableProps> = ({ headers, rows }) => {
    return (
        <div className="p-4">
            <div className="bg-white shadow-md rounded-lg overflow-hidden">
                <div className="overflow-x-auto">
                    <table className="w-full whitespace-nowrap">
                        <thead>
                            <tr className="bg-gray-300">
                                {headers.map((head, index) => (
                                    <th
                                        key={index}
                                        className="border-b border-gray-200 px-4 py-2 text-xs sm:text-sm font-semibold text-blue-gray-700"
                                    >
                                        {head}
                                    </th>
                                ))}
                            </tr>
                        </thead>
                        <tbody>
                            {rows.map((row, rowIndex) => {
                                const isLast = rowIndex === rows.length - 1;
                                const rowClasses = isLast ? "bg-white" : "bg-white";

                                return (
                                    <tr
                                        key={rowIndex}
                                        className={`hover:bg-gray-50 transition-colors ${rowClasses}`}
                                    >
                                        {row.map((cell, cellIndex) => (
                                            <td key={cellIndex} className="border-b border-gray-200 px-4 py-3 text-sm sm:text-base text-blue-gray-900">
                                                {typeof cell === 'string' ? (
                                                    <span className="flex items-center">
                                                        {cell}
                                                        {cellIndex === 0 && <PhotoIcon className="w-5 h-5 ml-1 text-blue-gray-500" />}
                                                    </span>
                                                ) : (
                                                    cell
                                                )}
                                            </td>
                                        ))}
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

export default Table;
