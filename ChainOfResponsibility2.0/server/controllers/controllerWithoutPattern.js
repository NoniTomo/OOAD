import HandlerWithoutPattern from './HandlerWithoutPattern.js';

class Controller {
    static async acc(req, res) {
        const sum = req.body.sum;
        if(sum > 500000) return res.status(403);
        console.log(req.body);
        try {
            const handlerWithoutPattern = new HandlerWithoutPattern();

            let object = [];
            const result = await handlerWithoutPattern.handler({sum, result : object});
            console.log('Controller | result', result);
            res.status(200).json(JSON.stringify(result.filter(item => item.count !== 0)));
        } catch (error) {
            console.log(error);
        }
    }
}

export default Controller;
