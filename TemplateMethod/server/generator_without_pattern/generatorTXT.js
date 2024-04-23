import db from '../db.js';

class GeneratorTXT {
    async template() {
        const data = await this.getDataFromDB();
        return await this.generate(data);
    }
    async getDataFromDB() {
        const result = await db.query('SELECT * FROM file;');
        return result.rows;
    }
    async generate(data) {
        let text = '';
        data.forEach(row => {
            text += `${row.title}\n`;
            text += `${row.text}\n`;
            text += '\n';
        })
        return text;
    }
}

export default GeneratorTXT;