import React, { useState } from 'react';
import axios from 'axios';

function App() {
    const [input, setInput] = useState('');
    const [result, setResult] = useState('');

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const response = await axios.post('https://localhost:7114/Currency/convert', { amount: input });
            setResult(response.data.result);
        } catch (error) {
            console.error('Error converting currency:', error);
            setResult('Error converting currency.');
        }
    };

    return (
        <div>
            <h1>Currency to Words Converter</h1>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    value={input}
                    onChange={e => setInput(e.target.value)}
                    placeholder="Enter currency in numbers, e.g., 123,45"
                />
                <button type="submit">Convert</button>
            </form>
            {result && <p>{result}</p>}
        </div>
    );
}

export default App;
