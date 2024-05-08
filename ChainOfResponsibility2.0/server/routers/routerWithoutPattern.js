import { Router } from 'express';
import Controller from '../controllers/controllerWithoutPattern.js';

const router = Router();

router.post('/acc', Controller.acc);

export default router;