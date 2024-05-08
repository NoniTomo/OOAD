import axios from "axios";
import { createContext, memo } from "react";
import { useState } from "react";

export const UserContext = createContext()

export default function UserDataContext ({children}) {
    const [resultValue, setResultValue] = useState('');
    const [allBank, setAllBank] = useState([]);
    const ResourceClient = axios.create({
        baseURL: 'http://localhost:8090',
      });

    async function handleRequest({value, navigate, handleClick}){
    await ResourceClient.post('/acc', {
            sum: value
        })
        .then((res) => {
            setResultValue('');
            setAllBank(JSON.parse(res.data))
            navigate('/result');
        })
        .catch((error) => {
            handleClick('Ошибка при отправке запроса');
            console.log(error);
        })
    }

    return (
        <UserContext.Provider
            value={{
                handleRequest,
                setResultValue,
                resultValue,
                allBank
            }}
        >
            {children}
        </UserContext.Provider>
    )
}