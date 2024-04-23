import db from '../db.js';

class TemplateGenerator {
    async template() {
        const data = await this.getDataFromDB();
        return await this.generate(data);
    }
    async getDataFromDB() {
        const result = await db.query('SELECT * FROM file;');
        return result.rows;
    }
}
export default TemplateGenerator;