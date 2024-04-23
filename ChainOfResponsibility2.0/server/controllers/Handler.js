
class Handler {
    setNext(nextHandler){
        this.next = nextHandler;
    }
}

export class Handler5000 extends Handler {
    count = 5000;

    async handler({sum, result}) {
        console.log(`1) Handler${this.count} | sum = `, sum);
        if (sum % this.count >= 0) {
            result.push({value: this.count, 'count' : (sum - sum % this.count) / this.count});
            sum = sum % this.count
            console.log(`2) Handler${this.count} | sum = `, sum);
        } 
        console.log(`3) Handler${this.count} | this.next && sum !== 0 = `, this.next && sum !== 0);
        console.log(`4) Handler${this.count} | result `, result);
        if(this.next && sum !== 0) return await this.next.handler({sum, result});
        return result;
    }
}
export class Handler1000 extends Handler {
    count = 1000;

    async handler({sum, result}) {
        console.log(`1) Handler${this.count} | sum = `, sum);
        if (sum % this.count >= 0) {
            result.push({value: this.count, 'count' : (sum - sum % this.count) / this.count});
            sum = sum % this.count;
            console.log(`2) Handler${this.count} | sum = `, sum);
        } 
        console.log(`3) Handler${this.count} | this.next && sum !== 0 = `, this.next && sum !== 0);
        console.log(`4) Handler${this.count} | result `, result);
        if(this.next && sum !== 0) return await this.next.handler({sum, result});
        return result;
    }
}
export class Handler500 extends Handler {
    count = 500;

    async handler({sum, result}) {
        console.log(`1) Handler${this.count} | sum = `, sum);
        if (sum % this.count >= 0) {
            result.push({value: this.count, 'count' : (sum - sum % this.count) / this.count});
            sum = sum % this.count;
            console.log(`2) Handler${this.count} | sum = `, sum);

        } 
        console.log(`3) Handler${this.count} | this.next && sum !== 0 = `, this.next && sum !== 0);
        console.log(`4) Handler${this.count} | result `, result);
        if(this.next && sum !== 0) return await this.next.handler({sum, result});
        return result;
    }
}
export class Handler100 extends Handler {
    count = 100;

    async handler({sum, result}) {
        console.log(`1) Handler${this.count} | sum = `, sum);
        if (sum % this.count >= 0) {
            result.push({value: this.count, 'count' : (sum - sum % this.count) / this.count});
            sum = sum % this.count;
            console.log(`2) Handler${this.count} | sum = `, sum);

        } 
        console.log(`3) Handler${this.count} | this.next && sum !== 0 = `, this.next && sum !== 0);
        console.log(`4) Handler${this.count} | result `, result);
        if(this.next && sum !== 0) return await this.next.handler({sum, result});
        return result;
    }
}
export class Handler50 extends Handler {
    count = 50;

    async handler({sum, result}) {
        console.log(`1) Handler${this.count} | sum = `, sum);
        if (sum % this.count >= 0) {
            result.push({value: this.count, 'count' : (sum - sum % this.count) / this.count});
            sum = sum % this.count;
            console.log(`2) Handler${this.count} | sum = `, sum);

        } 
        console.log(`3) Handler${this.count} | this.next && sum !== 0 = `, this.next && sum !== 0);
        console.log(`4) Handler${this.count} | result `, result);
        if(this.next && sum !== 0) return await this.next.handler({sum, result});
        return result;
    }
}
export class Handler10 extends Handler {
    count = 10;

    async handler({sum, result}) {
        console.log(`1) Handler${this.count} | sum = `, sum);
        if (sum % this.count >= 0) {
            result.push({value: this.count, 'count' : (sum - sum % this.count) / this.count});
            sum = sum % this.count;
            console.log(`2) Handler${this.count} | sum = `, sum);

        } 
        console.log(`3) Handler${this.count} | this.next && sum !== 0 = `, this.next && sum !== 0);
        console.log(`4) Handler${this.count} | result `, result);
        if (sum > 0) result.push({value: 'remains', 'count' : sum});
        if(this.next && sum !== 0) return await this.next.handler({sum, result});
        return result;
    }
}

export default Handler;