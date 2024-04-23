import { Handler5000 } from './Handler.js';
import { Handler1000 } from './Handler.js';
import { Handler500 } from './Handler.js';
import { Handler100 } from './Handler.js';
import { Handler50 } from './Handler.js';
import { Handler10 } from './Handler.js';

class Controller {
    static async acc(req, res) {
        const sum = req.body.sum;
        if(sum > 500000) return res.status(406);
        console.log(req.body);
        try {
            console.log('Запрос принят на обработку');
            const handler5000 = new Handler5000();
            const handler1000 = new Handler1000();
            const handler500 = new Handler500();
            const handler100 = new Handler100();
            const handler50 = new Handler50();
            const handler10 = new Handler10();

            handler5000.setNext(handler1000);
            handler1000.setNext(handler500);
            handler500.setNext(handler100);
            handler100.setNext(handler50);
            handler50.setNext(handler10);

            let object = [];
            const result = await handler5000.handler({sum, result : object});
            console.log('Controller | result', result);
            res.status(200).json(JSON.stringify(result.filter(item => item.count !== 0)));
        } catch (error) {
            console.log(error);
        }
    }
}

export default Controller;
