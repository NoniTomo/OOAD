class HandlerWithoutPattern {
    count5000 = 5000;
    count1000 = 1000;
    count500 = 500;
    count100 = 100;
    count50 = 50;
    count10 = 10;

    async handler({sum, result}) {
        console.log(`1) Handler${this.count5000} | sum = `, sum);
        if (sum % this.count5000 >= 0) {
            result.push({value: this.count5000, 'count' : (sum - sum % this.count5000) / this.count5000});
            sum = sum % this.count5000
            console.log(`2) Handler${this.count5000} | sum = `, sum);
        } 
        console.log(`3) Handler${this.count5000} |  sum !== 0 = `,  sum !== 0);
        console.log(`4) Handler${this.count5000} | result `, result);
        if( sum !== 0) {
            console.log(`1) Handler${this.count1000} | sum = `, sum);
            if (sum % this.count1000 >= 0) {
                result.push({value: this.count1000, 'count' : (sum - sum % this.count1000) / this.count1000});
                sum = sum % this.count1000;
                console.log(`2) Handler${this.count1000} | sum = `, sum);
            } 
            console.log(`3) Handler${this.count1000} |  sum !== 0 = `,  sum !== 0);
            console.log(`4) Handler${this.count1000} | result `, result);
            if( sum !== 0) {
                console.log(`1) Handler${this.count500} | sum = `, sum);
                if (sum % this.count500 >= 0) {
                    result.push({value: this.count500, 'count' : (sum - sum % this.count500) / this.count500});
                    sum = sum % this.count500;
                    console.log(`2) Handler${this.count500} | sum = `, sum);

                } 
                console.log(`3) Handler${this.count500} |  sum !== 0 = `,  sum !== 0);
                console.log(`4) Handler${this.count500} | result `, result);
                if( sum !== 0) {
                    console.log(`1) Handler${this.count100} | sum = `, sum);
                    if (sum % this.count100 >= 0) {
                        result.push({value: this.count100, 'count' : (sum - sum % this.count100) / this.count100});
                        sum = sum % this.count100;
                        console.log(`2) Handler${this.count100} | sum = `, sum);
            
                    } 
                    console.log(`3) Handler${this.count100} |  sum !== 0 = `,  sum !== 0);
                    console.log(`4) Handler${this.count100} | result `, result);
                    if( sum !== 0) {
                        console.log(`1) Handler${this.count50} | sum = `, sum);
                        if (sum % this.count50 >= 0) {
                            result.push({value: this.count50, 'count' : (sum - sum % this.count50) / this.count50});
                            sum = sum % this.count50;
                            console.log(`2) Handler${this.count50} | sum = `, sum);

                        } 
                        console.log(`3) Handler${this.count50} |  sum !== 0 = `,  sum !== 0);
                        console.log(`4) Handler${this.count50} | result `, result);
                        if( sum !== 0) {
                            console.log(`1) Handler${this.count10} | sum = `, sum);
                            if (sum % this.count10 >= 0) {
                                result.push({value: this.count10, 'count' : (sum - sum % this.count10) / this.count10});
                                sum = sum % this.count10;
                                console.log(`2) Handler${this.count10} | sum = `, sum);

                            } 
                            console.log(`3) Handler${this.count10} |  sum !== 0 = `,  sum !== 0);
                            console.log(`4) Handler${this.count10} | result `, result);
                            if (sum > 0) result.push({value: 'remains', 'count' : sum});
                            return result;
                        };
                        return result;
                    };
                    return result;
                };
                return result;
            };
            return result;
        };
        return result;
    }
}

export default HandlerWithoutPattern;