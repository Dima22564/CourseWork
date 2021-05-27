<template>
  <div class="q-pa-md">
    <q-stepper
      v-model="step"
      vertical
      color="primary"
      animated
      keep-alive
    >
      <q-step
        :name="1"
        title="Заполните КП"
        icon="settings"
        caption="обязательно для заполнения"
        :done="step > 1"
      >
        <q-form
          class="q-gutter-md"
          @submit.prevent=""
          ref="companyData"
        >
          <q-input
            filled
            v-model="form.number"
            label="Номер"
            hint="Номер"
            dense
          />

          <q-select
            :disable="loading"
            :option-label="item => item.name.workName"
            option-value="partnerId"
            dense
            filled
            v-model="form.partner"
            :options="partners"
            label="Компания"
          />

          <q-input
            filled
            v-model="form.from"
            label=""
            hint="С Даты"
            lazy-rules
            type="date"
            dense
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="form.validFrom"
            label=""
            hint="Действует с"
            lazy-rules
            type="date"
            dense
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="form.validTo"
            label=""
            hint="Действует по"
            type="date"
            lazy-rules
            dense
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />
        </q-form>

        <q-stepper-navigation>
          <q-btn @click="onSubmit" color="primary" label="Создать" />
        </q-stepper-navigation>
      </q-step>

      <q-step
        :name="2"
        title="Добавить продукты"
        caption="Продукты для КП"
        icon="create_new_folder"
        :done="step > 2"
      >
        <q-form
          class="q-gutter-md"
          @submit.prevent=""
          ref="companyAddress"
        >
          <q-btn :to="'/store/product/all?createBp=true&number=' + $route.query.number" color="primary" label="Выбрать товары" />
          <q-table
            title="Введите цену и количество товаров"
            :data="bpProducts"
            :columns="columns"
            row-key="productId"
            binary-state-sort
          >
            <template v-slot:body="props">
              <q-tr :props="props">
                <q-td key="productId" :props="props">
                  {{ props.row.productId }}
                </q-td>
                <q-td key="name" :props="props">
                  {{ props.row.workName }}
                </q-td>
                <q-td key="quantity" :props="props">
                  {{ props.row.quantity }}
                  <q-popup-edit
                    :value="props.row.quantity"
                    title="Обновить количетво"
                    :buttons="true"
                    label-set="Обновить"
                    label-cancel="Отмена"
                  >
                    <q-input v-model="props.row.quantity" dense autofocus />
                  </q-popup-edit>
                </q-td>
                <q-td key="price" :props="props">
                  {{ props.row.price }}
                  <q-popup-edit
                    :value="props.row.price"
                    title="Обновить цену"
                    :buttons="true"
                    label-set="Обновить"
                    label-cancel="Отмена"
                  >
                    <q-input v-model="props.row.price" dense autofocus />
                  </q-popup-edit>
                </q-td>
                <q-td key="sale" :props="props">
                  {{ props.row.sale }}
                  <q-popup-edit
                    :value="props.row.sale"
                    title="Скидка %"
                    @input="changeProductProp(Number($event), props.row.productId, 'sale')"
                    :buttons="true"
                    label-set="Обновить"
                    label-cancel="Отмена"
                  >
                    <q-input @input="changeProductProp(Number($event), props.row.productId, 'sale')" :value="props.row.sale" dense autofocus />
                  </q-popup-edit>
                </q-td>

                <q-td key="total" :props="props">
                  {{ props.row.price * props.row.quantity * (100 - props.row.sale) / 100 }}
                </q-td>

                <q-td key="actions" :props="props">
                  <q-btn @click="deleteProduct(props.row.productId)" size="sm" color="negative" icon="delete" />
                </q-td>
              </q-tr>
            </template>
          </q-table>
        </q-form>

        <q-stepper-navigation>
          <q-btn @click="OnSubmitAdd" color="primary" label="Добавить" />
          <q-btn flat @click="nextStep($refs.companyAddress, 1)" color="primary" label="Назад" class="q-ml-sm" />
        </q-stepper-navigation>
      </q-step>

    </q-stepper>
  </div>
</template>

<script>
export default {
  name: 'ClientOrderCreate',
  data () {
    return {
      loading: false,
      form: {
        number: null,
        from: null,
        validFrom: null,
        validTo: null,
        partner: null
      },
      columns: [
        { name: 'productId', align: 'left', label: '#', field: 'productId', sortable: true },
        { name: 'name', label: 'Название', field: 'name', sortable: true },
        { name: 'quantity', label: 'Количество', field: 'quantity' },
        { name: 'price', label: 'Цена за ед', field: 'price' },
        { name: 'sale', label: 'Скидка', field: 'sale' },
        { name: 'total', label: 'Сумма', field: 'total' },
        { name: 'actions', label: '', field: 'actions' }
      ]
    }
  },
  async mounted () {
    try {
      await this.$store.dispatch('partner/fetchAll')
    } catch (e) {
      this.$q.notify({
        type: 'negative',
        message: 'Что-то пошло не так( Не удалось загрузить данные.'
      })
    }
  },
  computed: {
    partners () {
      return this.$store.state.partner.partners
    },
    step () {
      return this.$store.state.businessProposal.step
    },
    bpProducts () {
      return this.$store.state.businessProposal.businessProposalProducts
    }
  },
  methods: {
    deleteProduct (productId) {
      this.$store.commit('businessProposal/deleteProduct', productId)
    },
    changeProductProp (val, productId, propName) {
      this.$store.commit('businessProposal/update', { val, productId, propName })
    },
    async OnSubmitAdd () {
      this.loading = true

      try {
        const result = await this.$store.dispatch('businessProposal/addProducts', this.$route.query.number)
        if (result.status === 200) {
          await this.$router.replace('/new-business-proposal')
          this.$store.commit('businessProposal/setProducts', [])
          this.$store.commit('businessProposal/changeStep', 1)
          this.$q.notify({
            type: 'positive',
            message: 'Товары добавлены'
          })
        }
      } catch (e) {
      } finally {
        this.loading = false
      }
    },
    async onSubmit () {
      this.loading = true
      const bp = {
        Number: Number(this.form.number),
        From: this.form.from,
        ValidFrom: this.form.validFrom,
        ValidTo: this.form.validTo,
        PartnerId: this.form.partner.partnerId
      }

      try {
        const result = await this.$store.dispatch('businessProposal/create', bp)
        if (result.status === 201) {
          this.form.number = result.data.number
          await this.$router.replace('/new-business-proposal?number=' + result.data.number)
          this.$q.notify({
            type: 'positive',
            message: 'КП создано успешно'
          })

          this.nextStep(this.$refs.companyData, 2)
        }
      } catch (e) {
      } finally {
        this.loading = false
      }
    },
    nextStep (form, step) {
      form.validate().then(success => {
        if (success) {
          this.$store.commit('businessProposal/changeStep', step)
        }
      })
    }
  }
}
</script>
