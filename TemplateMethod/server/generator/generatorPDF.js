import PDFDocument from 'pdfkit';
import TemplateGenerator from './templateGenerator.js';

class GeneratorPDF extends TemplateGenerator {
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