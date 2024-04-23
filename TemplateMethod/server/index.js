import express from 'express';
import cors from 'cors';
import Router from './routes.js';

const PORT = 8080;

const app = express();

app.use(express.json());
app.use(cors());

app.use('/api', Router);

Router.get('/gets', (req, res) => {
    res.send('Запрос обработан!');
});
const start = async () => {
    try {
        app.listen(PORT, (err) => {
            if(err) return console.log(err);
            console.log(`server started on port ${PORT}`);
            }
        );
        
    } catch (e) {
        console.log(e);
    }
}

start();