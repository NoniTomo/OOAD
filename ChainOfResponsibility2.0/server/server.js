import express from 'express';
import cors from 'cors';
import dotenv from 'dotenv';
import Router from './routers/router.js';
import RouterWithoutPattern from './routers/routerWithoutPattern.js';

const PORT = process.env.PORT || 8090;
dotenv.config();

const app = express();

app.use(express.json());
app.use(cors({ origin: process.env.CLIENT_URL }));

app.use("/", Router);
//app.use("/", RouterWithoutPattern);

app.listen(PORT, () => {
    console.log("Серввер успешно запущен на порте 8090");
})