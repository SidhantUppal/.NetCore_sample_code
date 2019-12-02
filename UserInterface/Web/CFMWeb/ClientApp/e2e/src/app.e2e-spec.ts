import { AppPage } from './app.po';
import { browser, by, element, Key, ExpectedConditions} from 'protractor';
describe('App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('RulesPageTest', async () => {
    
    //browser.debugger();
    debugger;
    await page.navigateToRules();
    await page.WaitForElementToAppearByID('btnNewRule');
    element(by.id('btnNewRule')).click();

    var until = ExpectedConditions;
    console.log("Checking modal now");
    browser.waitForAngularEnabled(true);
    //let ele = browser.driver.findElement(by.css('modal-title')).getText();
    //console.log(ele);
    
    await page.WaitForElementToAppear(until.presenceOf(element(by.tagName("ngb-modal-window"))), 10);
    


    //await page.WaitForElementToAppear(until.presenceOf(element(by.css("modal-title2222"))), 100);
//
    //by.css("modal-title")
    //await this.WaitForElementToAppear(until.textToBePresentInElement($('#abc'), 'foo'), 10);
//
    /*
    await page.WaitForElementToAppearByID('btnNewRule22222222222');
   element(by.buttonText('Cancel')).click();
   element(by.buttonText('Rule')).click();
   browser.actions().sendKeys(Key.CONTROL).perform();
   browser.actions().sendKeys(Key.CONTROL).perform();
   browser.actions().sendKeys(Key.CONTROL).perform();
   element(by.buttonText('Save')).click();
   //browser.actions().mouseUp(element(by.xpath('//*[@id="RulesGrid1"]/div[4]/div[3]')), { x: yyyyyyyyyyyqqqwwwwwwwwwwaqqqqNew rule11111qqqqqqqqqqqqqqqqqqtest1222, y: undefined }).perform();
   element(by.xpath('//*[@id="RulesGrid1"]/div[4]/div[3]')).click();
   element(by.buttonText('Rule')).click();
   element(by.buttonText('Save')).click();
   element(by.xpath('//*[@id="RulesGrid1"]/div[4]/div[3]')).click();
   element(by.xpath('//*[@id="RulesGrid1"]/div[4]/div[3]/div[1]/div[9]/div[1]/i[1]')).click();
   browser.actions().sendKeys(Key.TAB).perform();
   element(by.xpath('/html[1]/body[1]/ngb-modal-window[1]/div[1]/div[1]/app-create-rule-or-version[1]/div[1]/div[1]/div[2]/form[1]/div[1]/div[2]/input[1]')).sendKeys('  ');
   element(by.buttonText('Cancel')).click();
   element(by.xpath('//*[@id="RulesGrid1"]/div[4]/div[3]/div[1]/div[9]/div[1]/i[1]')).click();
   element(by.buttonText('Save')).click();
   element(by.xpath('//*[@id="RulesGrid1"]/div[4]/div[3]')).click();
   element(by.xpath('//*[@id="RulesGrid1"]/div[4]/div[3]')).click();
   element(by.xpath('//*[@id="RulesGrid1"]/div[4]/div[3]')).click();
   element(by.xpath('//*[@id="RulesGrid1"]/div[4]/div[3]')).click();
    element(by.xpath('//*[@id="RulesGrid1"]/div[4]/div[3]/div[1]/div[9]/div[2]')).click();
    */
  }, 120000);
});
