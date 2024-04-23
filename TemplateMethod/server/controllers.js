import db from './db.js';
//import GeneratorPDF from './generator/generatorPDF.js';
//import GeneratorTXT from './generator/generatorTXT.js';

import GeneratorPDF from './generator_without_pattern/generatorPDF.js';
import GeneratorTXT from './generator_without_pattern/generatorTXT.js';


class Controllers {
    async save(req, res){
        const {title, text} = req.body;
        await db.query('INSERT INTO file (title, text) values ($1, $2) RETURNING *;', [title, text]);
        res.status(200).send("File saved successfully"); // Отправляем ответ
    }

    async generatorPDFmethod(req, res){
        const generator = new GeneratorPDF();
        const doc = await generator.template();

        const filename = `Forms.pdf`;
        const stream = res.writeHead(200, {
            'Content-Type': 'application/pdf',
            'Content-disposition': `attachment;filename=${filename}.pdf`,
        });
        doc.on('data', (chunk) => stream.write(chunk));
        doc.on('end', () => stream.end());
        doc.end();
        console.log('PDF файл создан');
    }

    async generatorTXTmethod(req, res){
        const generator = new GeneratorTXT();
        const doc = await generator.template();
        const fileName = `Forms.pdf`;
        res.setHeader('Content-Disposition', `attachment; filename="${fileName}"`);
        res.send(doc);
        console.log('TXT файл создан');
    }
}

export default new Controllers();