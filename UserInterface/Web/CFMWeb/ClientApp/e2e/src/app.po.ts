import { browser, by, element, ExpectedConditions } from 'protractor';


export class AppPage {
  navigateTo() {
    return browser.get('/');
  }
  searchedElementFound: boolean = false;
  searchedElementQueued: boolean = false;
  async WaitForElementToAppear_old(by, maxWait) {
    
    let currentwaitTime = 1;
    this.searchedElementFound = false;
    this.searchedElementQueued = false;
    while (currentwaitTime < maxWait) {
      try {
        var until = ExpectedConditions;
        let thisClass = this;
        browser.isElementPresent(element(by)).then(function(isPresent) {
          thisClass.searchedElementFound = true;
        });
        browser.wait(until.presenceOf(element(by)), 5000, 'Element taking too long to appear in the DOM');
        if (this.searchedElementFound) {
          return;
        } else {
          await this.delay(1000);

        }
      }
      catch (Exception) {


      }
      currentwaitTime = currentwaitTime + 1;
    }


    
  }

  async WaitForElementToAppear(until, maxWait) {

    let currentwaitTime = 1;
    this.searchedElementFound = false;
    this.searchedElementQueued=false;
    while (currentwaitTime < maxWait) {
      console.log(currentwaitTime);
      console.log(maxWait);
        let thisClass = this;
      if (this.searchedElementFound) {
        return;
      }
      try {
        if (!this.searchedElementQueued) {
          

          browser.wait(until, 30000).then(function(isPresent) {
            console.log("qqq" + isPresent);
            if (isPresent) {
              thisClass.searchedElementFound = true;
            }

          });
        }
        this.searchedElementQueued = true;
      } catch (e) {

      }
      console.log(this.searchedElementFound);
        if (this.searchedElementFound) {
          return;
        } else {
          await this.delay(2000);

        }
      
       
      currentwaitTime = currentwaitTime + 1;
    }



  }

  async WaitForElementToAppearByID(id) {

    var until = ExpectedConditions;

    await this.WaitForElementToAppear(until.presenceOf(element(by.id(id))), 10);
// 



  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }
 async LoginUser(page) {

   //await browser.get('/#/Login');
   browser.get(page);
    /*console.log("Sleeping11111 now");
    console.log(new Date());
    //browser.wait(null, 10000);
    //browser.wait(null, 5 * 1000, 'Server should start within 5 seconds');
    browser.sleep(5000);
    console.log("awake now");
    console.log(new Date());
    */
   var until = ExpectedConditions;
   
   await this.WaitForElementToAppear(until.presenceOf(element(by.id('validationCustomUsername'))),20);
//    browser.wait(until.presenceOf(element(by.id('validationCustomUsername'))), 5000, 'Element taking too long to appear in the DOM');

  // console.log(element(by.id('validationCustomUsername')));
   
   browser.element(by.id('validationCustomUsername')).sendKeys('test@test.com');
   browser.element(by.id('password')).sendKeys('test');
   browser.element(by.buttonText('Login')).click();
    console.log(page);
    
   const EC = ExpectedConditions;

   await this.WaitForElementToAppear(EC.urlContains(page), 10);

    //browser.wait(EC.urlContains(page), 5000);

    //console.log("wait done in");
    /*
    browser.wait(EC.urlContains(page), 5000).then(function (result) {
      expect(result).toEqual(true);
    });
    */
    //browser.driver.sleep(5000);
  }

  async navigateToRuleset() {
    await this.LoginUser('/#/Login?returnUrl=%2FRuleset');
 }

 async navigateToRules() {
   await this.LoginUser('/#/Login?returnUrl=%2FRules');
    const EC = ExpectedConditions;
    //browser.wait(EC.urlContains('/#/Rules'), 5000);
    /*

    console.log("Sleeping11111 now");
    console.log(new Date());
    var thisClass = this;
    browser.sleep(5000).then(function () {
      console.log('waited 10 seconds');
      thisClass.LoginUser('/#/Rules');
    });
    //browser.wait(null, 5 * 1000, 'Server should start within 5 seconds');
    browser.sleep(5000);
    console.log("awake now");
    console.log(new Date());
    */
  //  this.LoginUser('/#/Rules');
    //console.log("bbbb in");
    //browser.driver.sleep(5000);
    //console.log(browser.getCurrentUrl());
    //browser.resetUrl = '/#/Rules';
    //console.log("resdide");
    //browser.driver.sleep(50000);
    //return browser.get('/#/Rules');
  }
  getMainHeading() {
    return element(by.css('app-root h1')).getText();
  }
}
