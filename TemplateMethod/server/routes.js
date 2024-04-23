import express from 'express';
const router = express.Router();
import controller from './controllers.js';

router.get('/gets', (req, res) => {
    res.send('Запрос обработан!');
});
router.get('/generator-pdf', controller.generatorPDFmethod);
router.get('/generator-txt', controller.generatorTXTmethod);
router.post('/save', controller.save);

export default router;