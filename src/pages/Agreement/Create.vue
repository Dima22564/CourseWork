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
        title="Соглашение с клиентом (создание)"
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

    </q-stepper>
  </div>
</template>

<script>
export default {
  name: 'AgreementCreate',
  data () {
    return {
      loading: false,
      step: 1,
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
        const result = await this.$store.dispatch('agreement/create', bp)
        if (result.status === 201) {
          this.$q.notify({
            type: 'positive',
            message: 'Соглашение создано успешно'
          })
        }
      } catch (e) {
      } finally {
        this.loading = false
      }
    }
  }
}
</script>
