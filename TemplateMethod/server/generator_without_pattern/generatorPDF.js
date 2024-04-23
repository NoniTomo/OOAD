import PDFDocument from 'pdfkit';
import db from '../db.js';

class GeneratorPDF {
    async template() {
        const data = await this.getDataFromDB();
        return await this.generate(data);
    }
    async getDataFromDB() {
        const result = await db.query('SELECT * FROM file;');
        return result.rows;
    }
    async generate(data) {
        const doc = new PDFDocument({bufferPages: true, size: 'A4' });

        data.forEach(row => {
            doc.font('./Roboto/Roboto-Regular.ttf').fontSize(14).text(row.title);
            doc.moveDown();
            doc.fontSize(12).moveDown().text(row.text);
            doc.moveDown(2);
        });

        return doc;
    }
}

export default GeneratorPDF;
