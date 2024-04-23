import TemplateGenerator from './templateGenerator.js';

class GeneratorTXT extends TemplateGenerator {
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
